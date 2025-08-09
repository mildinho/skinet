import { Produto } from "./produto";
import { Produto_Detalhe } from "./produto_detalhe";
import { Produto_Imagem } from "./produto_imagem";
import { Produto_Similar } from "./produto_similar";

export type BuscaProduto = {
    produto : Produto,
    detalhe : Produto_Detalhe[],
    imagens : Produto_Imagem[],
    similar : Produto_Similar[]
}