import Styles from "./saldoGeral.module.css";
import { BankOutlined, MoneyCollectOutlined } from "@ant-design/icons";

export default function SaldoGeral() {
    return (
        <section className={Styles.container}>
            <div className={Styles.saldoGeral}>
                <p className={Styles.label}>Saldo geral</p>
                <p className={Styles.valor}>
                    <span className={Styles.moeda}>R$</span>15.000,00
                </p>
            </div>
            <div className={Styles.contasBox}>
                <h2 className={Styles.tituloContas}>Minhas Contas</h2>
                <ul className={Styles.listaContas}>
                    <li className={Styles.itemConta}>
                        <BankOutlined className={`${Styles.iconeConta} ${Styles.coraIcone}`} />
                        <span>Cora</span>
                    </li>
                    <li className={Styles.itemConta}>
                        <BankOutlined className={`${Styles.iconeConta} ${Styles.nubankIcone}`} />
                        <span>Nubank</span>
                    </li>
                    <li className={Styles.itemConta}>
                        <MoneyCollectOutlined className={`${Styles.iconeConta} ${Styles.dinheiroIcone}`} />
                        <span>Dinheiro</span>
                    </li>
                </ul>
            </div>
        </section>
    );
}
