import Link from 'next/link';
import Styles from './menuFixo.module.css';
import { SettingOutlined, BellOutlined } from '@ant-design/icons';
import { Avatar } from 'antd';
import type { MenuProps } from 'antd';
import { Menu } from 'antd';
import Image from 'next/image';

const itemsConfiguracoes: MenuProps['items'] = [
    {
        label: '',
        key: 'SubMenu',
        icon: <SettingOutlined />,
        children: [
            {
                type: 'group',
                label: 'Categorias',
                children: [
                    { label: 'Opção 1', key: 'setting:1' },
                    { label: 'Opção 2', key: 'setting:2' },
                ],
            },

        ],
    },
];
const itemsNotificacoes: MenuProps['items'] = [
    {
        label: '',
        key: 'Notificacoes',
        icon: <BellOutlined />,
        children: [
            {
                type: 'group',
                label: 'Alertas',
                children: [
                    { label: 'Aviso 1', key: 'alerta:1' },
                    { label: 'Aviso 2', key: 'alerta:2' },
                ],
            },
        ],
    },
];


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
                    <Menu className={Styles.menuConfig}
                        mode="horizontal"
                        items={itemsConfiguracoes}
                        theme="dark"
                        style={{ background: 'transparent', borderBottom: 'none' }}
                    />
                    <li>
                        <Menu
                            mode="horizontal"
                            items={itemsNotificacoes}
                            theme="dark"
                            style={{ background: 'transparent', borderBottom: 'none' }}
                        />
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