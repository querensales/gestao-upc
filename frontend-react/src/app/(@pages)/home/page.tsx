import ContasApagar from "@/app/components/visao_geral/contasApagar/contasApagar";
import Style from "./page.module.css";
import MaioresGastos from "@/app/components/visao_geral/maioresGastos/maioresGastos";
import SaldoGeral from "@/app/components/visao_geral/saldoGeral/saldoGeral";
import VisaoGeral from "@/app/components/visao_geral/visaogeral/visaoGeral";

export default function HomePagina() {
    return (
        <main className={Style.container}>
            <VisaoGeral />

            <section className={Style.section}>
                <SaldoGeral />
                <MaioresGastos />
                <ContasApagar />
            </section>
            
        </main>
    );
}
