import Link from 'next/link';
import Styles from './menuFixo.module.css';

export default function MenuFixo() {
    return (
        <header className={Styles.cabecalho}>
            <div className={Styles.logo}>LOGO</div>
            <nav className={Styles.menu}>
                <Link href="/" className={Styles.link}>
                    visão geral
                </Link>
                <Link href="/" className={Styles.link}>
                    lançamentos
                </Link>
                <Link href="/" className={Styles.link}>
                    relatórios
                </Link>
                <Link href="/" className={Styles.link}>
                    limite de gastos
                </Link>
                <Link href="/" className={Styles.link}>
                    conexão bancária
                </Link>
            </nav>
            <nav className={Styles.config}>
                <ul>
                    <li>configurações</li>
                    <li>alertas</li>
                    <li>conta</li>
                </ul>
            </nav>

        </header>
    )
}