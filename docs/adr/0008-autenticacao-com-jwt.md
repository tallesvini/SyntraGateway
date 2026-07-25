# ADR 0006 - Autenticação com JWT

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

A plataforma disponibilizará APIs protegidas para clientes externos.

Era necessário um mecanismo de autenticação stateless, compatível com APIs REST.

## Decisão

Foi adotada autenticação baseada em JSON Web Token (JWT).

Após autenticação do Client utilizando ClientId e ClientSecret, será emitido um Access Token contendo as informações necessárias para autorização das requisições.

## Justificativa

- Padrão amplamente utilizado;
- Não depende de sessão;
- Boa integração com ASP.NET Core.

## Consequências

### Positivas

- Escalabilidade;
- Baixo custo de validação;
- Compatibilidade com gateways e proxies.

### Negativas

- Necessidade de estratégias para revogação de tokens;
- Controle de expiração dos Access Tokens.