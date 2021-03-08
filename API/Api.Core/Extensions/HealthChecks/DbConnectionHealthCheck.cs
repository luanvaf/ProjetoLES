using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Core.Extensions.HealthChecks
{
    /// <summary>
    /// Verificação de saúde de conexão
    /// </summary>
    public class DbConnectionHealthCheck<T> : IHealthCheck
        where T : DbContext
    {
        private readonly T _connection;

        public DbConnectionHealthCheck(T connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Verificação de saúde de conexão
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HealthCheckResult> CheckHealthAsync
            (HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var data = new Dictionary<string, object>();

            try
            {
                data.Add(
                    "connection_string", RemoveUsernameAndPassword(_connection.Database.GetDbConnection().ConnectionString)
                );

                var canConnect = await _connection.Database.CanConnectAsync(cancellationToken);

                return canConnect
                    ? HealthCheckResult.Healthy("Conexão efetuada com sucesso!", data)
                    : HealthCheckResult.Unhealthy($"Não foi possível se conectar.", data: data);
            }
            catch (Exception exception)
            {
                /* O HealthCheckResult.Unhealthy pode receber uma exception como argumento, porém
                 * o objeto de exceção possui loops de referências e o System.Text.Json
                 * ainda não permite ignorar loops na hora da serialização, vide:
                 * https://github.com/dotnet/runtime/issues/40099
                 * isso quebra o endpoint de healthchecks, por isso eu estou adicionando as
                 * informações da exceção separadamente.
                 */
                data.Add("stack_trace", exception.StackTrace ?? "empty stack trace");
                data.Add("message", exception.Message);
                return HealthCheckResult.Unhealthy($"Não foi possível se conectar.", data: data);
            }
        }

        private static string RemoveUsernameAndPassword(string connectionString)
        {
            bool startsWith(string str, params string[] patterns)
                => patterns.Any(p => str.TrimStart().StartsWith(p, StringComparison.OrdinalIgnoreCase));

            return string.Join(';', connectionString
                .Split(';')
                .Where(str => !startsWith(str, "p", "u")));
        }
    }
}
