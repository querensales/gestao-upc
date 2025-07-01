import Styles from './acessoRapido.module.css';
import {
    UpCircleOutlined,
    DownCircleOutlined,
    RightCircleOutlined,
    VerticalAlignTopOutlined
} from '@ant-design/icons';

export default function acessoRapido() {
    return (
        <section className={Styles.section}>
            <h1>Acesso rápido</h1>
            <div>
                <ul>
                    <li className={Styles.despesa}>
                        <span className={Styles.icone}><DownCircleOutlined /></span>
                        <span className={Styles.label}>DESPESA</span>
                    </li>
                    <li className={Styles.receita}>
                        <span className={Styles.icone}><UpCircleOutlined /></span>
                        <span className={Styles.label}>RECEITA</span>
                    </li>
                    <li className={Styles.transf}>
                        <span className={Styles.icone}><RightCircleOutlined /></span>
                        <span className={Styles.label}>TRANSF.</span>
                    </li>
                    <li className={Styles.importar}>
                        <span className={Styles.icone}><VerticalAlignTopOutlined /></span>
                        <span className={Styles.label}>IMPORTAR</span>
                    </li>
                </ul>
            </div>
        </section>
    )
}