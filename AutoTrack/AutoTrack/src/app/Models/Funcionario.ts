export interface Funcionario {
    id: number;
    nome: string;
    cpf: string;
    dataAdmissao: Date;
    dataDemissao: Date | null;
    situacao: string;
    dataFerias: Date | null;
    funcao: string;
    dataNascimento: Date;
    celular1: string;
    celular2: string;
    rua: string;
    cep: string;
    cidade: string;
    bairro: string;
    foto: string;
  }