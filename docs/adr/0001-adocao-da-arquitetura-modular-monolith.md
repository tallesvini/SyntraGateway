# ADR 0001 - Adoção da Arquitetura Modular Monolith

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

O Syntra é uma plataforma de API Management cujo objetivo é centralizar o gerenciamento de integrações entre sistemas, APIs SaaS, ERPs e outros serviços externos.

Desde o início do projeto, buscou-se uma arquitetura que proporcionasse:

- Separação clara de responsabilidades;
- Facilidade de manutenção e evolução;
- Baixo acoplamento entre funcionalidades;
- Escalabilidade da base de código;
- Simplicidade operacional durante as fases iniciais do projeto;
- Possibilidade de evolução para microserviços caso necessário.

## Decisão

Foi adotada a arquitetura **Modular Monolith**.

O sistema será dividido em módulos independentes, cada um responsável por um contexto de negócio específico.

Cada módulo possuirá suas próprias camadas:

- Domain
- Application
- Infrastructure
- Presentation

Todos os módulos serão hospedados por uma única aplicação ASP.NET Core.

Exemplo da estrutura:

```text
Modules
├── Management
├── Client
├── Integration
├── Gateway
├── Billing
└── Webhook
```

Cada módulo deverá possuir baixo acoplamento em relação aos demais, comunicando-se através de contratos, eventos ou abstrações, evitando dependências diretas entre implementações.

## Justificativa

A arquitetura Modular Monolith foi escolhida pelos seguintes motivos:

- Mantém a simplicidade de implantação de um monólito;
- Organiza o domínio em contextos bem definidos;
- Facilita a evolução do projeto conforme novas funcionalidades são adicionadas;
- Reduz o acoplamento entre áreas do sistema;
- Facilita testes e manutenção;
- Permite futura extração de módulos para microserviços sem grandes refatorações.

## Consequências

### Positivas

- Organização do código por contexto de negócio;
- Maior legibilidade da solução;
- Evolução independente dos módulos;
- Menor complexidade operacional em comparação com microserviços;
- Facilidade de onboarding de novos desenvolvedores.

### Negativas

- Necessidade de disciplina para evitar dependências indevidas entre módulos;
- Compartilhamento do mesmo processo e banco de dados durante a fase monolítica;
- Não oferece isolamento físico entre módulos.

## Tecnologias adotadas

- ASP.NET Core
- .NET 9
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation

## Padrões Arquiteturais

Além do Modular Monolith, o projeto adota:

- Domain-Driven Design (DDD)
- CQRS
- Vertical Slice Architecture (Application)
- Repository Pattern
- Unit of Work
- Result Pattern

## Considerações Futuras

Caso determinado módulo apresente necessidades específicas de escalabilidade, disponibilidade ou implantação independente, será considerada sua extração para um microserviço, preservando os contratos estabelecidos durante o desenvolvimento da arquitetura modular.