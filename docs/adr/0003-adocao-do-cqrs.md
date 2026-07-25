# ADR 0003 - Adoção do CQRS

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

O Syntra possui operações de leitura e escrita com características distintas.

Operações de escrita envolvem validações e regras de negócio, enquanto operações de leitura normalmente exigem apenas consultas otimizadas.

## Decisão

Foi adotado o padrão CQRS (Command Query Responsibility Segregation).

Todas as operações serão divididas em:

- Commands
- Queries

Cada operação possuirá seu próprio Handler utilizando MediatR.

## Justificativa

- Separação entre leitura e escrita;
- Casos de uso menores e mais coesos;
- Melhor organização da camada Application;
- Facilidade para evolução futura.

## Consequências

### Positivas

- Código mais organizado;
- Melhor escalabilidade;
- Facilidade para testes.

### Negativas

- Maior quantidade de classes;
- Estrutura inicial mais extensa.