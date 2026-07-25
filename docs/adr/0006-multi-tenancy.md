# ADR 0007 - Estratégia de Multi-Tenancy

- **Status:** Aceito
- **Data:** 25/07/2026

## Contexto

O Syntra será disponibilizado como plataforma SaaS, permitindo múltiplas empresas utilizarem o mesmo sistema.

## Decisão

Foi adotado o modelo de banco compartilhado com isolamento lógico dos dados.

Todas as entidades pertencentes a um tenant implementarão a interface ITenantEntity.

O acesso aos dados será protegido através de filtros globais do Entity Framework Core.

## Justificativa

- Menor custo operacional;
- Facilidade de manutenção;
- Escalabilidade para o porte inicial do projeto.

## Consequências

### Positivas

- Compartilhamento de infraestrutura;
- Simplicidade de implantação.

### Negativas

- Necessidade de garantir isolamento dos dados entre tenants;
- Maior responsabilidade na implementação dos filtros.