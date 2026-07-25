# ADR 0005 - Persistência com Entity Framework Core

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

O Syntra necessita de persistência relacional para armazenar clientes, integrações, rotas, planos, usuários e demais informações da plataforma.

## Decisão

Foi adotado o Entity Framework Core como ORM oficial do projeto.

O acesso aos dados ocorrerá através de:

- DbContext
- Repository Pattern
- Unit of Work

## Justificativa

- Forte integração com .NET;
- Excelente suporte a migrations;
- Facilidade de manutenção;
- Alto nível de produtividade.

## Consequências

### Positivas

- Desenvolvimento mais rápido;
- Integração com LINQ;
- Grande comunidade.

### Negativas

- Necessidade de atenção em consultas complexas;
- Conhecimento do funcionamento interno do EF Core para evitar problemas de performance.