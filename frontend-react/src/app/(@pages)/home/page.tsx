import Style from "./page.module.css";
import MaioresGastos from "@/app/components/maioresGastos/maioresGastos";
import SaldoGeral from "@/app/components/saldoGeral/saldoGeral";
import VisaoGeral from "@/app/components/visaogeral/visaoGeral";

export default function HomePagina() {
    return (
        <main className={Style.container}>
            <VisaoGeral />

            <section className={Style.section}>
                <SaldoGeral />
                <MaioresGastos />
            </section>
            
        </main>
    );
}
