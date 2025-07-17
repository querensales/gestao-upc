import Styles from './boasVindas.module.css'

export default function boasVindas() {
    return (
        <section className={Styles.section}>
            <div className={Styles.ola}>
                <p>Olá,</p>
                <h2>Queren!</h2>
            </div>

            <div className={Styles.mesAtual}>
                <div>
                    <p>Receitas no mês atual</p>
                    <p>R$ 10.000,00</p>
                </div>
                <span className={Styles.divisor}>|</span>
                <div className={Styles.mesAtual}>
                    <p>Despesas no mês atual</p>
                    <p>R$ - 5.000,00</p>
                </div>
            </div>
        </section>
    )
}
