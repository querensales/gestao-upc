import AcessoRapido from "../acessoRapido/acessoRapido";
import BoasVindas from "../boasVindas/boasVindas";
import Styles from "./visaoGeral.module.css"
export default function VisaoGeral() {
    return (
        <div className={Styles.container}>
            <BoasVindas />
            <AcessoRapido />
        </div>
    );
}
