import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "../globals.css";
import MenuFixo from "../components/menufixo/menuFixo";

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
    <html lang="en">
      <body>
        <MenuFixo/>
        {children}
      </body>
    </html>
  );
}