# ADR 0008 - Adoção de API Gateway

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

O principal objetivo do Syntra é centralizar e controlar o acesso a APIs externas e sistemas integrados.

Era necessário um componente responsável por autenticação, autorização, roteamento e monitoramento das requisições.

## Decisão

O Syntra possuirá um módulo Gateway responsável por:

- Receber requisições dos Clients;
- Validar autenticação e autorização;
- Aplicar Rate Limiting;
- Encaminhar chamadas para APIs externas;
- Registrar logs e métricas;
- Futuramente suportar Webhooks, Cache e Circuit Breaker.

## Justificativa

- Centralização das integrações;
- Controle único de acesso;
- Facilidade de monitoramento.

## Consequências

### Positivas

- Maior segurança;
- Melhor observabilidade;
- Flexibilidade para adicionar novas funcionalidades.

### Negativas

- Maior responsabilidade do Gateway;
- Necessidade de atenção à performance.