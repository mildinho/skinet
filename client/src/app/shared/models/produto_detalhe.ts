export type Produto_Detalhe = {
    id: number;
    empresaid: number,
    produtoid: number,
    unidade_medida: string,
    ncm: string,
    multiplo_venda: number,
    base_venda: number,
    base_oferta: number,
    base_atacado: number,
    base_custo: number,
    base_medio: number,
    saldo_disponivel: number
}