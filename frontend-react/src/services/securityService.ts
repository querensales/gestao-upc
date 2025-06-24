import SigninModel from "@/models/security/signin.model";
import axios from "axios";

export const SecurityService = {
    signin: async (model: SigninModel) => {
        console.log("o que esta chegando:", model)
        const retornoApi = await axios.post('http://localhost:5223/api/Security', model)
        console.log('retorno da api', retornoApi)
    }
}