import { CreditCardOutlined, CalendarOutlined } from '@ant-design/icons';
import Styles from './contasApagar.module.css';

export default function ContasApagar() {
    const contas = [
        { id: 1, nome: 'Energia', valor: 350.00, vencimento: '10/07', icone: <CreditCardOutlined className={Styles.iconeConta} /> },
        { id: 2, nome: 'Internet', valor: 120.00, vencimento: '15/07', icone: <CreditCardOutlined className={Styles.iconeConta} /> },
        { id: 3, nome: 'Aluguel', valor: 1200.00, vencimento: '05/07', icone: <CreditCardOutlined className={Styles.iconeConta} /> },
    ];

    const formatarMoeda = (valor: number) => {
        return valor.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
    };

    return (
        <section className={Styles.container}>
            <div className={Styles.saldoGeral}>
            </div>
            <div className={Styles.contasBox}>
                <h2 className={Styles.tituloContas}>Contas a pagar</h2>
                <ul className={Styles.listaContas}>
                    {contas.map(conta => (
                        <li key={conta.id} className={Styles.itemConta}>
                            {conta.icone}
                            <span>{conta.nome}</span>
                            <p className={Styles.valorConta}>R$ {formatarMoeda(conta.valor)}</p>
                            <span className={Styles.vencimento}>
                                <CalendarOutlined /> {conta.vencimento}
                            </span>
                        </li>
                    ))}
                </ul>
            </div>
        </section>
    )
}