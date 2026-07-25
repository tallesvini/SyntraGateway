# ADR 0004 - Adoção da Vertical Slice Architecture

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

Projetos organizados por tipo de arquivo tendem a crescer com pastas contendo centenas de Commands, Handlers e Validators.

Isso dificulta a manutenção e localização das funcionalidades.

## Decisão

A camada Application será organizada utilizando Vertical Slice Architecture.

Cada caso de uso possuirá sua própria pasta contendo todos os arquivos necessários.

Exemplo:

Application/
└── UseCases/
    └── CreateClient/
        ├── Command.cs
        ├── Handler.cs
        ├── Validator.cs
        └── Response.cs

## Justificativa

- Organização por funcionalidade;
- Melhor manutenção;
- Escalabilidade da solução;
- Redução da navegação entre pastas.

## Consequências

### Positivas

- Funcionalidades isoladas;
- Maior produtividade durante manutenção.

### Negativas

- Estrutura diferente do padrão encontrado em muitos projetos.