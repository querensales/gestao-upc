'use client';

import Styles from "./saldoGeral.module.css";
import { BankOutlined, EyeOutlined, EyeInvisibleOutlined, MoneyCollectOutlined } from "@ant-design/icons";
import { useState } from "react";

export default function SaldoGeral() {
    const [mostrarSaldo, setMostrarSaldo] = useState(true);

    function VisualizarSaldo() {
        setMostrarSaldo((prev) => !prev);
    }

    return (
        <section className={Styles.container}>
            <div className={Styles.saldoGeral}>
                <p className={Styles.label}>Saldo geral</p>
                <p className={Styles.valor}>
                    <span className={Styles.moeda}>R$</span>
                    {mostrarSaldo ? "15.000,00" : "•••••••••"}
                    {mostrarSaldo ? (
                        <EyeOutlined
                            className={Styles.eyeOutlined}
                            onClick={VisualizarSaldo}
                        />
                    ) : (
                        <EyeInvisibleOutlined
                            className={Styles.eyeInvisibleOutlined}
                            onClick={VisualizarSaldo}
                        />
                    )}
                </p>
            </div>
            <div className={Styles.contasBox}>
                <h2 className={Styles.tituloContas}>Minhas Contas</h2>
                <ul className={Styles.listaContas}>
                    <li className={Styles.itemConta}>
                        <BankOutlined className={`${Styles.iconeConta} ${Styles.coraIcone}`} />
                        <span>Cora</span>
                        <p className={Styles.valorConta}>R$ 2.000,00</p>
                    </li>
                    <li className={Styles.itemConta}>
                        <BankOutlined className={`${Styles.iconeConta} ${Styles.nubankIcone}`} />
                        <span>Nubank</span>
                        <p className={Styles.valorConta}>R$ 2.000,00</p>
                    </li>
                    <li className={Styles.itemConta}>
                        <MoneyCollectOutlined className={`${Styles.iconeConta} ${Styles.dinheiroIcone}`} />
                        <span>Dinheiro</span>
                        <p className={Styles.valorConta}>R$ 2.000,00</p>
                    </li>
                </ul>
            </div>
        </section>
    );
}
