export interface Funcionario {
    id: number;
    nome: string;
    cpf: string;
    dataAdmissao: Date | null;
    dataDemissao: Date | null;
    situacao: string;
    dataFerias: Date | null;
    funcao: string;
    dataNascimento: Date | null;
    celular1: string;
    celular2: string;
    rua: string;
    cep: string;
    cidade: string;
    bairro: string;
    foto: File | null; // Permitir null;
  }