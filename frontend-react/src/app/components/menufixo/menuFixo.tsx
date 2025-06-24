import Link from 'next/link';
import Styles from './menuFixo.module.css';
import { SettingOutlined, BellOutlined } from '@ant-design/icons';
import { Avatar } from 'antd';
import Image from 'next/image';


export default function MenuFixo() {
    return (
        <header className={Styles.cabecalho}>
            <div className={Styles.logo}>
                <Image
                    src="/images/logoigreja.png"
                    alt="Logo da Unção Profética Church"
                    width={110}
                    height={50}
                />
            </div>
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
                    <li>
                        <SettingOutlined className={Styles.icon} />
                    </li>
                    <li><BellOutlined className={Styles.icon} />
                    </li>
                    <li>
                        <Avatar
                            src="https://i.pravatar.cc/40"
                            size={44}
                            alt="Foto do usuário"
                        />
                    </li>
                </ul>
            </nav>

        </header>
    )
}