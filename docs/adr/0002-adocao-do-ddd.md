# ADR 0002 - Adoção do Domain-Driven Design (DDD)

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

O Syntra possui regras de negócio relacionadas ao gerenciamento de clientes, integrações, autenticação, gateway, planos e faturamento.

A tendência é que o domínio cresça ao longo do tempo, tornando inadequada uma arquitetura baseada apenas em serviços e modelos anêmicos.

## Decisão

Foi adotado o Domain-Driven Design (DDD) como abordagem para modelagem do domínio.

As regras de negócio ficarão concentradas nas entidades e objetos de valor, enquanto a camada de Application será responsável apenas por orquestrar os casos de uso.

Cada módulo possuirá seu próprio domínio, contendo entidades, interfaces de repositório, eventos, enums e exceções específicas.

## Justificativa

- Centralização das regras de negócio;
- Baixo acoplamento entre domínio e infraestrutura;
- Modelo rico e orientado ao negócio;
- Facilidade para evolução das funcionalidades.

## Consequências

### Positivas

- Maior coesão das entidades;
- Facilidade para testes unitários;
- Redução de regras espalhadas em serviços.

### Negativas

- Curva de aprendizado maior para novos desenvolvedores;
- Modelagem inicial mais elaborada.

## Referências

- Eric Evans — Domain-Driven Design
- Vaughn Vernon — Implementing Domain-Driven Design