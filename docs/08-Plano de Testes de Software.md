## Plano de Testes de Software

| Casos de Teste | CT-01 - Criar usuário e senha |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-007 - O sistema terá tela de Login e senha // RNF-007 - A plataforma interativa deve permitir o acesso apenas de usuários cadastrados |
|`Objetivo do teste` | Testar o acesso a tela de login, criar um usário e senha e testar a redefinição de senha |
|`Passos` | 
||1 - Abrir o navegador  |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Clicar no botão "Criar um cadastro" |
||4 - Preencher os campos obrigatórios (Nome, Ultimo nome, E-mail, Username, Data de Nascimento, Telefone, Crie uma senha, Confirme a senha) |
||5 - Clicar no botão "Criar" > Clicar no botão "Esqueci minha senha" |
||6 - Preencher campo "E-mail" |
||7 - Clicar no botão "Enviar" |
|`Critério de Êxito` | O usuário criou um login e senha e conseguiu redefinir a senha. |
|`Avaliação` | O usuário "admin" e a senha "123456" foram criados, ***redefinição de senha?*** |


| Casos de Teste | CT-02 - Criar categorias |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-01 -  O sistema permite agrupar valores por seções (categorias) |
|`Objetivo do teste` | Testar a criação de categorias |
|`Dados de entrada` | Usuário: admin Senha: 123456 |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Usuário e Senha |
||4 - Clicar no botão "Entrar" |
||5 - Clicar no botão " + " |
||6 - Clicar no botão "Criar categoria" |
||7 - Clicar na categoria desejada |
||8 - Clicar no botão para selecionar categoria |
|`Critério de Êxito` | As categorias foram criadas. |
|`Avaliação` | As categorias "Casas, Uber Driver, Contas mensais, Lanches, Qualidade de vida" foram criadas. |


| Casos de Teste | CT-03 - Fazer lançamentos, visualizar lançamentos por mês (entradas e saída por mês) |
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-002 - O sistema permite o lançamento de débitos // RF-003 - O sistema permite o lançamento de créditos // RF-004 - O sistema permite datar lançamentos (exemplo: pagamentos ou recebimentos futuros)  // RF-005 - O sistema permite a visualização de entradas e saídas por mês |
|`Objetivo do teste` | Realizar lançamentos e filtrar a visualização por mês |
|`Dados de entrada` | Usuário: admin Senha: 123456 |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Usuário e Senha | 
||4 - Clicar no botão "Entrar" |
||5 - Clicar no botão " + " |
||6 - Clicar na categoria desejada |
||7 - Clicar no botão "Inserir" | 
||8 - Selecionar na lista o mês e ano desejado para filtrar |
||9 - Clicar no botão "Ok" |
|`Critério de Êxito` | Lançamentos feitos com sucesso, Filtros por período realizado. |
|`Avaliação` | Lançamentos de receita e despesa cadastrados. ***Avaliar o filtro*** |


| Casos de Teste | CT-04- Definir meta e visualizar alterações no status da meta|
|--------------------|------------------------------------|
|`Requisitos Associados` | RF-006 - O sistema permite a definição de meta e visualização do progresso de atingimento |
|`Objetivo do teste` | Definir meta |
|`Dados de entrada` | Usuário: admin Senha: 123456 |
|`Passos` | 
||1 - Abrir o navegador |
||2 - Informar o endreço do site https://localhost:44331/Usuarios/Login |
||3 - Informar o Usuário e Senha |
||4 - Clicar no botão "Entrar" |
||5 - Clicar no botão "Meta" |
||6 - Informar o valor da meta |
||7 - Clicar o botão "Inserir" | 
|`Critério de Êxito` | Meta cadastrada |
|`Avaliação` | A meta foi cadastrada e foi visualizado seu progresso de atingimento com base nos lançamentos da conta |
