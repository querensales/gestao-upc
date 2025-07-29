import BotaoLancamento from "@/app/components/botoesLancamentos/botaoLancamento";
import BotaoPesquisar from "@/app/components/botoesLancamentos/botaoPesquisar";


export default function Lancamentos() {
    return (
        <div>
            <h1>Página de Lançamentos</h1>
            <BotaoLancamento/>
            <BotaoPesquisar/>
        </div>
    );
}
