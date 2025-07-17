'use client';

import Styles from "../maioresGastos/maioresGastos.module.css";
import { HomeOutlined, DotChartOutlined, BulbOutlined } from "@ant-design/icons";


export default function MaioresGastos() {
    const gastosMes = [
        { id: 1, nome: "Aluguel", porcentagem: "50%", icone: <HomeOutlined className={`${Styles.iconeConta} ${Styles.coraIcone}`} /> },
        { id: 2, nome: "Água", porcentagem: "30%", icone: <DotChartOutlined className={`${Styles.iconeConta} ${Styles.nubankIcone}`} /> },
        { id: 3, nome: "Luz", porcentagem: "20%", icone: <BulbOutlined className={`${Styles.iconeConta} ${Styles.dinheiroIcone}`} /> },
    ];

    return (
        <section className={Styles.container}>
          
            <div className={Styles.contasBox}>
                <h2 className={Styles.tituloContas}>Maiores gastos do mês atual</h2>
                <ul className={Styles.listaContas}>
                    {gastosMes.map(gasto => (
                        <li key={gasto.id} className={Styles.itemConta}>
                            {gasto.icone}
                            <span>{gasto.nome}</span>
                            <p className={Styles.valorConta}>{gasto.porcentagem}</p>
                        </li>
                    ))}
                </ul>
            </div>
        </section>
    );
}
