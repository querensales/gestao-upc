import Styles from './boasVindas.module.css'

export default function boasVindas() {
    const informacoes = {
        nomeUsuario: 'Queren',
        receitaTotal: 10000,
        despesaTotal: 5000,
    }




    return (
        <section className={Styles.section}>
            <div className={Styles.ola}>
                <p>Olá,</p>
                <h2>{informacoes.nomeUsuario}!</h2>
            </div>

            <div className={Styles.mesAtual}>
                <div>
                    <p>Receitas no mês atual</p>
                    <p>R$ {informacoes.receitaTotal}</p>
                </div>
                <span className={Styles.divisor}>|</span>
                <div className={Styles.mesAtual}>
                    <p>Despesas no mês atual</p>
                    <p>R$ {informacoes.despesaTotal}</p>
                </div>
            </div>
        </section>
    )
}
