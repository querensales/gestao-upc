'use client';

import Styles from "./maioresGastos.module.css";
import { HomeOutlined, DotChartOutlined, BulbOutlined } from "@ant-design/icons";


export default function MaioresGastos() {


    return (
        <section className={Styles.container}>
          
            <div className={Styles.contasBox}>
                <h2 className={Styles.tituloContas}>Maiores gastos do mês atual</h2>
                <ul className={Styles.listaContas}>
                    <li className={Styles.itemConta}>
                        <HomeOutlined className={`${Styles.iconeConta} ${Styles.coraIcone}`} />
                        <span>Aluguel</span>
                        <p className={Styles.valorConta}>50%</p>
                    </li>
                    <li className={Styles.itemConta}>
                        <DotChartOutlined className={`${Styles.iconeConta} ${Styles.nubankIcone}`} />
                        <span>água</span>
                        <p className={Styles.valorConta}>50%</p>
                    </li>
                    <li className={Styles.itemConta}>
                        <BulbOutlined className={`${Styles.iconeConta} ${Styles.dinheiroIcone}`} />
                        <span>Luz</span>
                        <p className={Styles.valorConta}>50%</p>
                    </li>
                </ul>
            </div>
        </section>
    );
}
