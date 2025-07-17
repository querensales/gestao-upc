import type { Metadata } from "next";
import "../globals.css";
import MenuFixo from "../components/visao_geral/menufixo/menuFixo";

export const metadata: Metadata = {
  title: "Unção Profética Church",
  description: "igreja unção profética church",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="pt-br">
      <body>
        <MenuFixo/>
        {children}
      </body>
    </html>
  );
}