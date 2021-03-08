import DocterUser from "./docterUser";
import { ResidentEnum } from "./helps/residentEnum";

export default interface Resident extends DocterUser {
    ResidenceYear: ResidentEnum
}