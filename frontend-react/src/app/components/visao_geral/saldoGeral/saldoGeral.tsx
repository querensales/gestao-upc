'use client';

import React, { useState, useEffect } from 'react';
import { EyeOutlined, EyeInvisibleOutlined, BankOutlined, MoneyCollectOutlined } from '@ant-design/icons';
import Styles from './saldoGeral.module.css';

function SaldoGeral() {
    const [mostrarSaldo, setMostrarSaldo] = useState(true);
    const [totalSaldo, setTotalSaldo] = useState(0);
    
    // eslint-disable-next-line react-hooks/exhaustive-deps
    const contas = [
        { id: 1, nome: 'Cora', valor: 5000.00, icone: <BankOutlined className={`${Styles.iconeConta} ${Styles.coraIcone}`} /> },
        { id: 2, nome: 'Nubank', valor: 2000.00, icone: <BankOutlined className={`${Styles.iconeConta} ${Styles.nubankIcone}`} /> },
        { id: 3, nome: 'Dinheiro', valor: 2000.00, icone: <MoneyCollectOutlined className={`${Styles.iconeConta} ${Styles.dinheiroIcone}`} /> },
    ];

    useEffect(() => {
        const soma = contas.reduce((acc, conta) => acc + conta.valor, 0);
        setTotalSaldo(soma);
    },[contas ]);

    const VisualizarSaldo = () => {
        setMostrarSaldo(!mostrarSaldo);
    };

    const formatarMoeda = (valor: number) => {
        return valor.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
    };

    return (
        <section className={Styles.container}>
            <div className={Styles.saldoGeral}>
                <p className={Styles.label}>Saldo geral</p>
                <p className={Styles.valor}>
                    <span className={Styles.moeda}>R$</span>
                    {mostrarSaldo ? formatarMoeda(totalSaldo) : "•••••••••"}
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
                    {contas.map(conta => (
                        <li key={conta.id} className={Styles.itemConta}>
                            {conta.icone}
                            <span>{conta.nome}</span>
                            <p className={Styles.valorConta}>R$ {formatarMoeda(conta.valor)}</p>
                        </li>
                    ))}
                </ul>
            </div>
        </section>
    );
}

export default SaldoGeral;