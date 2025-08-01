import { pessoaResponse } from "@/models/response/pessoa.response";

export async function BuscarTodos(): Promise<pessoaResponse[]> {

    const response = await fetch("http://localhost:5223/api/Queren/buscar-todos")
    console.log("API AQUI:", response)
    console.log(response.status)
    const resultadoApi : pessoaResponse[] = await response.json()
    return resultadoApi
}