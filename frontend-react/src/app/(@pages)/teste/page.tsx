'use client'
import { pessoaResponse } from "@/models/response/pessoa.response"
import { useState } from "react"

export default function TesteApi() {
    const [pessoas] = useState<pessoaResponse[]>([])


    return (
        <div>
            <table>
                <tr>
                    <th>ID</th>
                    <th>nome</th>
                    <th>cpf</th>
                    <th>data de nasc.</th>
                </tr>
                <tbody>
                    {pessoas.map((pessoa) => (
                        <tr key={pessoa.id}>
                            <td>{pessoa.id}</td>
                            <td>{pessoa.nome}</td>
                            <td>{pessoa.cpf}</td>
                            <td>{pessoa.dataNascimento.toString()}</td>
                        </tr>
                    ))}
                </tbody>

            </table>
        </div>
    )
}