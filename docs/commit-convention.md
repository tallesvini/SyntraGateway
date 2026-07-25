# Git Commit Convention

Este projeto utiliza o padrão **Conventional Commits** para manter o histórico de alterações organizado, facilitar a revisão de código e identificar rapidamente quais módulos foram impactados.

## Estrutura

```text
<tipo>(<escopo>): <descrição>
```

O **escopo** é opcional e representa o módulo ou área da aplicação afetada.

**Exemplos:**

```text
feat(auth): implementar autenticação JWT

fix(person): corrigir validação de CPF

docs(readme): atualizar instruções de instalação

refactor(shared): simplificar classe Result
```

Ou sem escopo:

```text
feat: implementar autenticação JWT

fix: corrigir validação do login
```

---

# Tipos de Commit

| Tipo | Descrição |
|------|-----------|
| `feat` | Adiciona uma nova funcionalidade. |
| `fix` | Corrige um bug. |
| `docs` | Altera apenas documentação. |
| `style` | Ajustes de formatação (sem alterar lógica). |
| `refactor` | Refatora código sem alterar comportamento. |
| `perf` | Melhora de performance. |
| `test` | Adiciona ou altera testes. |
| `build` | Alterações em dependências, Docker, NuGet, npm, etc. |
| `ci` | Alterações em pipelines de integração contínua. |
| `chore` | Tarefas de manutenção que não impactam a lógica da aplicação. |
| `revert` | Reverte um commit anterior. |

---

# Escopos

Os escopos representam o módulo ou área do sistema que sofreu alteração.

| Escopo | Descrição |
|---------|-----------|
| `auth` | Autenticação e autorização |
| `person` | Gestão de pessoas |
| `client` | Gestão de clientes |
| `department` | Departamentos |
| `branch` | Filiais |
| `audit` | Auditoria |
| `notification` | Notificações |
| `document` | Documentos |
| `attachment` | Anexos |
| `workflow` | Fluxos de aprovação |
| `permission` | Permissões |
| `role` | Perfis de acesso |
| `dashboard` | Dashboards |
| `report` | Relatórios |
| `integration` | Integrações externas |
| `gateway` | Gateway/API Management |
| `shared` | Shared Kernel / Código compartilhado |
| `infra` | Infraestrutura |
| `database` | Banco de dados |
| `docs` | Documentação |

> Utilize sempre o nome do módulo quando a alteração estiver relacionada a uma funcionalidade específica.

---

# Exemplos

### Nova funcionalidade

```text
feat(person): criar cadastro de pessoas
```

### Correção de bug

```text
fix(auth): corrigir renovação do token JWT
```

### Refatoração

```text
refactor(shared): simplificar classe Result
```

### Banco de dados

```text
feat(database): criar tabelas de auditoria
```

### Documentação

```text
docs(readme): atualizar estrutura do projeto
```

### Integração

```text
feat(integration): adicionar integração com ERP
```

### Permissões

```text
feat(permission): implementar permissões por módulo
```

### Dashboard

```text
feat(dashboard): adicionar indicadores de vendas
```

### Infraestrutura

```text
build(infra): adicionar configuração do Docker Compose
```

---

# Boas práticas

- Faça commits pequenos e objetivos.
- Cada commit deve representar apenas uma alteração lógica.
- Utilize verbos no infinitivo ou imperativo, mantendo um padrão em todo o projeto.
- Seja descritivo na mensagem do commit.
- Evite mensagens genéricas como:
  - `ajustes`
  - `update`
  - `changes`
  - `correções`

---

# Exemplos recomendados

```text
feat(auth): implementar autenticação JWT

feat(person): criar cadastro de pessoas

feat(client): implementar gerenciamento de clientes

feat(permission): criar controle de permissões

feat(audit): registrar auditoria das operações

fix(database): corrigir chave estrangeira da tabela Person

refactor(shared): simplificar classe Result

docs(readme): atualizar documentação de instalação

build(infra): adicionar Docker Compose

ci(github): configurar pipeline de CI

chore: atualizar dependências
```