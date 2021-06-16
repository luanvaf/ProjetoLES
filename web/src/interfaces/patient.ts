import { SexTypeEnum } from "./helps/sexTypeEnum";
import Address from "./address";

export default interface patient {
    Name: String;
    Cpf: String;
    BirthDate: Date;
    Sex: SexTypeEnum;
    Phone: String;
    Address: Address
}