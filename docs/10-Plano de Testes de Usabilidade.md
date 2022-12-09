## Plano de Testes de Usabilidade


**Avaliação Funcional (feita pelo usuário que faz transações – casos de uso)**

| Atividade a ser realizada | Feedback do usuário | Considerações (quais os problemas, deficiências, limitações, etc) | Sugestão de melhorias |
|--------------------|------------------------------------|------------------------------------|------------------------------------|
| Cadastro de usuário - Campos obrigatórios: Nome, Sobrenome, E-mail, Data de nascimento, Telefone, Senha, Confirmação da senha | Consegui cadastrar o usuário sem problemas | O campo de telefone está permitindo infinitos caractéres, assim como "ano" na data de nascimento | Limitar os campos de caracteres citados| 
| Realizar login na aplicação - Campos obrigatórios: Usuário, E-mail ou telefone e senha | Consegui realizar o login na aplicação | Nenhum | Nenhuma | 
| Cadastrar categorias | Consegui cadastrar as categorias desejadas | Nenhuma | Nenhuma | 
| Realizar um lançamento - Campos obrigatórios: Data, Valor, Categoria, Descrição | Consegui realizar o lançamento | Não consegui identificar se o lançamento era receita ou despesa | Identificar se os lançamentos são despesas ou receitas | 
| Excluir um lançamento | Consegui excluir o lançamento desejado | Não foi solicitado confirmação de exclusão | A aplicação poderia solicitar confirmação de exclusão de lançamento | 
| Editar um lançamento | Funcionou corretamente a alteração de dados de um lançamento | Nenhuma | Nenhuma | 
| Visualizar lançamento por período (Filtro por semana, mês ou ano) | Foi possível filtrar os lançamentos por mês e também visualizar do ano | Nenhuma | Nenhuma | 
| Definir metas | Consegui definir uma meta e visualizar o status do alcance da meta | Não foi possível visualizar uma porcetagem para o atingimento da meta | Incluir uma forma de exibir o percentual alcançado da meta definida |

**Detalhamento Análise Heurística**
| ID | Característica | Sim - Não - N/A | Comentários |
|:---------------|:------------------------------------|------------------------------------|:------------------------------------|
| 1 - Visibilidade do status do sistema |
| 1.1 | As telas do sistema iniciam com um título que descreve seu conteúdo? | [x] [ ] [ ] |  |
| 1.2 | O ícone selecionado é destacado dos demais não selecionados? | [ ] [x] [ ] |  |
| 1.3 | Há feedback visual do menu ou escolhas selecionadas? | [ ] [ ] [x] |  |
| 1.4 | O sistema provê visibilidade do estado atual e alternativas para ação? | [ ] [ ] [x] |  |
| 2 - Correspondência entre sistema e mundo real |
| 2.1 | Os ícones e ilustrações são concretos e familiares? | [x] [ ] [ ] |  |
| 2.2 | As cores, quando utilizadas, correspondem aos códigos de cores comuns? | [x] [ ] [ ] |  |
| 2.3 | A linguagem utilizada evita jargões técnicos? | [x] [ ] [ ] |  |
| 2.4 | Os números são devidamente separados nos milhares e nos decimais? | [x] [ ] [ ] |  |
| 3 - Controle de usuário e liberdade |
| 3.1 | Se o sistema utiliza janelas que se sobrepõem, ele permite a organização e troca simples? | [ ] [x] [ ] |  |
| 3.2 | Quando o usuário conclui uma tarefa, o sistema aguarda uma ação antes de processar? | [ ] [x] [ ] |  |
| 3.3 | O usuário é solicitado a confirmar tarefas que possuem consequências drásticas? | [ ] [x] [ ] |  |
| 3.4 | Existe uma funcionalidade para desfazer ações realizadas pelo usuário? | [ ] [x] [ ] |  |
| 3.5 | O usuário pode editar, copiar e colar durante a entrada de dados? | [x] [ ] [ ] |  |
| 3.6 | O usuário pode se mover entre campos e janelas livremente? | [x] [ ] [ ] |  |
| 3.7 | O usuário pode configurar o sistema, a sessão, a tela conforme sua preferência? | [ ] [x] [ ] |  |
| 4 - Consistência e padrões |
| 4.1 | O sistema evita uso constante de letras maiúsculas? | [x] [ ] [ ] |  |
| 4.2 | Os números são justificados à direita e alinhados quanto aos decimais? | [ ] [x] [ ] |  |
| 4.3 | Os ícones e ilustrções são rotulados? | [x] [ ] [ ] |  |
| 4.4 | As instruções aparecem de forma consistente sempre no mesmo local? | [ ] [x] [ ] |  |
| 4.5 | Os objetos do sistema são nomeados de maneira consistente em todo o sistema? | [x] [ ] [ ] |  |
| 4.6 | Os campos obrigatórios e opcionais são corretamente sinalizados? | [x] [ ] [ ] |  |
| 5 - Prevenção de erros |
| 5.1 | As opções de menu são lógicas, distintas e mutualmente exclusivas? | [ ] [ ] [x] |  |
| 5.2 | Se o sistema exibe múltiplas janelas, a navegação entre janelas é simples e visível? | [ ] [ ] [x] |  |
| 5.3 | O sistema alerta o usuário se ele está prestes a fazer erros críticos? | [ ] [x] [ ] |  |
| 6 - Reconhecimento ao invés de recordação |
| 6.1 | Há distinção clara quando é possível selecionar um item ou vários? | [ ] [ ] [x] |  |
| 6.2 | Os rótulos de campo estão próximos dos campos e separados pelo menos um espaço? | [x] [ ] [ ] |  |
| 6.3 | São utilizadas bordas para identificar possiveis grupos de elementos? | [x] [ ] [ ] |  |
| 6.4 | Existem opções default para o que o usuário precisa selecionar? | [ ] [x] [ ] |  |
| 6.5 | Há alguma diferença visível para identificar a janela ativa? | [x] [ ] [ ] |  |
| 7 - Flexibilidade e eficiência de uso |
| 7.1 | Existem atalhos para as funções disponíveis no sistema? | [x] [ ] [ ] |  |
| 7.2 | O usuário pode realizar a tarefa de maneiras mais simplificadas? | [ ] [ ] [x] |  |
| 7.3 | O sistema permite integração com outras fontes das informações tratadas? | [ ] [x] [ ] |  |
| 8 - Estética e design minimalista |
| 8.1 | Apenas a informação necessária para ação está visível na tela? | [x] [ ] [ ] |  |
| 8.2 | Os ícones e ilustrações estão distintos do seu fundo? | [x] [ ] [ ] |  |
| 8.3 | Os agrupamentos são separados por espaço em branco? | [x] [ ] [ ] |  |
| 8.4 | Os rótulos e menus são breves, familiares e descritivos das opções que representam? | [ ] [ ] [x] |  |
| 9 - Ajudar os usuários e reconhecer, diagnosticar se recuperar de erros |
| 9.1 | É utilizado um sinal sonoro para alertar de erros? | [ ] [ ] [x] |  |
| 9.2 | Os questionamentos são breves e sem ambiguidade? | [ ] [ ] [x] |  |
| 9.3 | Se um erro é detectado, o usuário tem visibilidade sobre qual o local gerador do erro? | [ ] [x] [ ] |  |
| 9.4 | As mensagens de erro identificam a severidade e a causa do erro? | [ ] [ ] [x] |  |
| 9.5 | As mensagens de erro sugerem uma ação para correção? | [ ] [ ] [x] |  |
| 10 - Ajuda e documentação |
| 10.1 | As instruções online estão visualmente distintas? | [ ] [ ] [x] |  |
| 10.2 | Existe ajuda online sensível ao contexto? | [ ] [ ] [x] |  |
| 10.3 | É simples o acesso a ajuda do sistema e retorno ao sistema? | [ ] [ ] [x] |  |


**Avaliação Estática (inspeção feita pela equipe de desenvolvimento ou alguém interno)**
| Heurísticas |	Notas dos avaliadores |	Média	| Consenso |	Considerações |	Melhorias |
|---------------|------------------------------------|------------------------------------|------------------------------------|------------------------------------|------------------------------------|
| Visibilidade do status do sistema | Avaliador1: 1 Avaliador2: 1 Avaliador3: 1 | 1 | 1 | A aplicação não exibe status do sistema | Nenhuma
| Correspondência entre sistema e mundo real | Avaliador1: 3 Avaliador2: 3 Avaliador3: 3 | 3 | 3 | Nenhuma | Nenhuma
| Controle de usuário e liberdade | Avaliador1: 2 Avaliador2: 2 Avaliador3: 2 | 2 | 2 | Nenhuma | Nenhuma 
| Consistência e padrões | Avaliador1: 2 Avaliador2: 2 Avaliador3: 2 | 2 | 2 | Nenhuma | Nenhuma 
| Prevenção de erros | Avaliador1: 1 Avaliador2: 1 Avaliador3: 1 | 1 | 1 | O sistema não propõe prevenções de possíveis erros  | Nenhuma
| Reconhecimento ao invés de recordação | Avaliador1: 2 Avaliador2: 1 Avaliador3: 1 | 1,33 | 2 | Nenhuma | Nenhuma
| Flexibilidade e eficiência de uso | Avaliador1: 1 Avaliador2: 1 Avaliador3: 2 | 1,33 | 1 | Nenhuma | Nenhuma
| Estética e design minimalista | Avaliador1: 3 Avaliador2: 3 Avaliador3: 3 | 3 | 3 | Nenhuma | Nenhuma
| Ajudar os usuários e reconhecer, diagnosticar se recuperar de erros | Avaliador1: 1 Avaliador2: 1 Avaliador3: 1 | 1 | 1 | O sistema não exibe como tratar um possível erro | Nenhuma
| Ajuda e documentação | Avaliador1: 1 Avaliador2: 1 Avaliador3: 1 | 1 | 1 | Nenhuma | Nenhuma

**O que fazer para melhorar**
| Heurísticas |	Melhoria |
|---------------|------------------------------------|
| Visibilidade do status do sistema | Nenhuma
| Correspondência entre sistema e mundo real | Nenhuma
| Controle de usuário e liberdade | Nenhuma
| Consistência e padrões | Nenhuma
| Prevenção de erros | Seria interessante o sistema solicitar uma confirmação para uma ação drástica 
| Reconhecimento ao invés de recordação | Nenhuma 
| Flexibilidade e eficiência de uso | Nenhuma
| Estética e design minimalista | Nenhuma 
| Ajudar os usuários e reconhecer, diagnosticar se recuperar de erros | Seria interessante o sistema exibir a mensagem de erro indicando onde ocorreu o erro e como trata-lo
| Ajuda e documentação | Seria importante ter um guia/fórum de dúvidas frenquentes e disponibilizar o acesso a documentação da aplicação para o usuário
