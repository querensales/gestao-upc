import { Input } from "antd";


export default function BotaoPesquisar() {
  return (
    <div>
      <Input
        placeholder="Buscar por nome, tipo ou data"
        allowClear
        size="middle"
      />
    </div>
  );
}
