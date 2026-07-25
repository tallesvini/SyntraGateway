# Estratégia de Branches

Este projeto adota uma estratégia baseada no **Git Flow Simplificado**, utilizando as branches `main` e `develop` como base para o desenvolvimento.

O objetivo é manter a branch de produção sempre estável, enquanto a branch `develop` concentra as funcionalidades em desenvolvimento até a próxima versão.

---

# Estrutura

```text
                   main
                     ▲
                     │
             Pull Request (Release)
                     │
                  develop
              ▲      ▲      ▲
              │      │      │
              PR     PR     PR
              │      │      │
            feature/ fix/ refactor/
```

---

# Branches

## `main`

A branch **main** representa o ambiente de produção.

Características:

- Contém apenas versões estáveis.
- Não recebe commits diretamente.
- Recebe alterações apenas através de Pull Requests da `develop`.
- Cada merge deve gerar uma nova versão do sistema.

---

## `development`

A branch **development** representa o ambiente de desenvolvimento/homologação.

Características:

- É a base para criação das branches de trabalho.
- Consolida todas as funcionalidades da próxima versão.
- Após validação, é mesclada na `main`.

---

# Branches de Trabalho

Toda alteração deve possuir uma branch própria.

## Nova funcionalidade

```text
feature/<nome-da-funcionalidade>
```

Exemplos:

```text
feature/person
feature/authentication
feature/client-management
feature/audit
feature/dashboard
```

---

## Correção

```text
fix/<descricao>
```

Exemplos:

```text
fix/login-validation
fix/token-expiration
fix/person-search
```

---

## Refatoração

```text
refactor/<descricao>
```

Exemplos:

```text
refactor/person-service
refactor/result-pattern
```

---

## Documentação

```text
docs/<descricao>
```

Exemplos:

```text
docs/readme
docs/api
docs/database
```

---

## Testes

```text
test/<descricao>
```

Exemplos:

```text
test/authentication
test/person-service
```

---

## Hotfix

Utilizado apenas para correções urgentes em produção.

```text
hotfix/<descricao>
```

Exemplos:

```text
hotfix/jwt-expiration
hotfix/database-connection
```

---

# Fluxo de Desenvolvimento

## 1. Atualizar a branch `develop`

```bash
git checkout develop
git pull origin develop
```

---

## 2. Criar uma branch

```bash
git checkout -b feature/person
```

A nova branch sempre deve ser criada a partir da `develop`.

---

## 3. Desenvolver

Realize os commits seguindo a convenção do projeto.

Exemplo:

```text
feat(person): criar cadastro de pessoas

feat(person): implementar listagem

fix(person): corrigir validação de CPF
```

---

## 4. Enviar para o GitHub

```bash
git push origin feature/person
```

---

## 5. Abrir Pull Request

O Pull Request deve ser aberto para a branch **develop**.

```text
  feature/person
        │
        ▼
     develop
```

Após aprovação e merge, a branch poderá ser removida.

---

## 6. Publicação da versão

Quando todas as funcionalidades da versão estiverem concluídas e homologadas:

```text
 develop
    │
    ▼
Pull Request
    │
    ▼
  main
```

Após o merge na `main`, uma nova versão do sistema será publicada.

---

# Fluxo Completo

```text
                   main
                     ▲
                     │
            Pull Request (Release)
                     │
                  develop
            ┌────────┼─────────┐
            │        │         │
            ▼        ▼         ▼
        feature/*   fix/*   refactor/*
            │        │         │
            └────────┼─────────┘
                     │
                Pull Request
                     │
                     ▼
                  develop
                     │
             Homologação/Testes
                     │
                     ▼
             Pull Request (Release)
                     │
                     ▼
                   main
                     │
                     ▼
                 Criar Tag
                     │
                     ▼
             Publicar Release
```

---

# Versionamento

O projeto utiliza **Semantic Versioning (SemVer)**.

Formato:

```text
MAJOR.MINOR.PATCH
```

Exemplos:

```text
v1.0.0
v1.1.0
v1.2.0
v1.2.1
v2.0.0
```

## Regras

| Versão | Quando utilizar |
|---------|-----------------|
| **MAJOR** | Alterações incompatíveis com versões anteriores. |
| **MINOR** | Inclusão de novas funcionalidades compatíveis. |
| **PATCH** | Correções de bugs e pequenas melhorias. |

### Exemplos

```text
v1.0.0 → Primeira versão estável

v1.1.0 → Novo módulo de Pessoas

v1.2.0 → Novo módulo de Auditoria

v1.2.1 → Correção na autenticação

v1.2.2 → Correção na geração de relatórios

v2.0.0 → Mudança incompatível na API
```

---

# Tags

Toda publicação realizada na branch **main** deve possuir uma Tag correspondente.

Exemplos:

```text
v1.0.0
v1.1.0
v1.2.0
v1.2.1
```

Criando uma Tag:

```bash
git checkout main
git pull origin main

git tag -a v1.0.0 -m "Release v1.0.0"

git push origin v1.0.0
```

Ou enviar todas as Tags:

```bash
git push origin --tags
```

---

# Releases

Após criar a Tag, deve ser criada uma **GitHub Release** correspondente.

A Release deve conter:

- Versão publicada.
- Data da publicação.
- Novas funcionalidades.
- Correções realizadas.
- Melhorias implementadas.
- Breaking Changes (quando houver).

Exemplo:

## v1.2.0

### 🚀 Novas funcionalidades

- Cadastro de Pessoas
- Gestão de Clientes
- Controle de Permissões

### 🐞 Correções

- Correção na renovação do JWT.

### ⚡ Melhorias

- Otimização das consultas ao banco.

---

# Boas Práticas

- Nunca realize commits diretamente na `main`.
- Sempre crie uma branch para cada tarefa.
- Mantenha as branches pequenas e objetivas.
- Faça Pull Requests com apenas uma alteração lógica.
- Atualize a `develop` antes de iniciar uma nova tarefa.
- Toda versão publicada deve possuir uma Tag e uma GitHub Release.