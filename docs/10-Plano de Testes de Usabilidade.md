## Plano de Testes de Usabilidade


**Avaliação Funcional (feita pelo usuário que faz transações – casos de uso)**

| Atividade a ser realizada | Feedback do usuário | Considerações (quais os problemas, deficiências, limitações, etc) | Sugestão de melhorias |
|--------------------|------------------------------------|------------------------------------|------------------------------------|
| Cadastro de usuário - Campos obrigatórios: Nome, Sobrenome, E-mail, Data de nascimento, Telefone, Senha, Confirmação da senha | Consegui cadastrar o usuário sem problemas | O campo de telefone está permitindo infinitos caractéres, assim como "ano" na data de nascimento | Limitar os campos de caracteres citados| 
| Realizar login na aplicação - Campos obrigatórios: Usuário, E-mail ou telefone e senha | Consegui realizar o login na aplicação | Nenhum | Nenhuma | 
| Cadastrar categorias | Consegui cadastrar as categorias desejadas | Somente consegui cadastrar as categorias acessando a parte de criação direto pelo endpoint | Adicionar o botão de "criar categoria". Informar se o lançamento é débito ou crédito. 
| Realizar um lançamento - Campos obrigatórios: Data, Valor, Categoria, Descrição | Consegui realizar o lançamento | Não consegui identificar se o lançamento era receita ou despesa | Identificar se os lanaçamentos são despesas ou receitas | 
| Programar Lançamentos | ???????? | ???????? | ???????? |
| Excluir um lançamento | ???????? | ???????? | ???????? | 
| Editar um lançamento | ???????? | ???????? | ???????? | 
| Visualizar lançamento por período (Filtro por semana, mês ou ano) | ???????? | ???????? | ???????? | 
| Definir metas | ???????? | ???????? | ???????? |
| Simular cenários | ???????? | ???????? | ???????? |
| Visualizar Relatórios | ???????? | ???????? | ???????? |

**Detalhamento Análise Heurística**
| ID | Característica | Sim Não N/A | Comentários |
|:---------------|:------------------------------------|------------------------------------|:------------------------------------|
| 1 - Visibilidade do status do sistema |
| 1.1 | As telas do sistema iniciam com um título que descreve seu conteúdo? | [ ] [ ] [ ] |  |
| 1.2 | O ícone selecionado é destacado dos demais não selecionados? | [ ] [ ] [ ] |  |
| 1.3 | Há feedback visual do menu ou escolhas selecionadas? | [ ] [ ] [ ] |  |
| 1.4 | O sistema provê visibilidade do estado atual e alternativas para ação? | [ ] [ ] [ ] |  |
| 2 - Correspondência entre sistema e mundo real |
| 2.1 | Os ícones e ilustrações são concretos e familiares? | [ ] [ ] [ ] |  |
| 2.2 | As cores, quando utilizadas, correspondem aos códigos de cores comuns? | [ ] [ ] [ ] |  |
| 2.3 | A linguagem utilizada evita jargões técnicos? | [ ] [ ] [ ] |  |
| 2.4 | Os números são devidamente separados nos milhares e nos decimais? | [ ] [ ] [ ] |  |
| 3 - Controle de usuário e liberdade |
| 3.1 | Se o sistema utiliza janelas que se sobrepõem, ele permite a organização e troca simples? | [ ] [ ] [ ] |  |
| 3.2 | Quando o usuário conclui uma tarefa, o sistema aguarda uma ação antes de processar? | [ ] [ ] [ ] |  |
| 3.3 | O usuário é solicitado a confirmar tarefas que possuem consequências drásticas? | [ ] [ ] [ ] |  |
| 3.4 | Existe uma funcionalidade para desfazer ações realizadas pelo usuário? | [ ] [ ] [ ] |  |
| 3.5 | O usuário pode editar, copiar e colar durante a entrada de dados? | [ ] [ ] [ ] |  |
| 3.6 | O usuário pode se mover entre campos e janelas livremente? | [ ] [ ] [ ] |  |
| 3.7 | O usuário pode configurar o sistema, a sessão, a tela conforme sua preferência? | [ ] [ ] [ ] |  |
| 4 - Consistência e padrões |
| 4.1 | O sistema evita uso constante de letras maíusculas? | [ ] [ ] [ ] |  |
| 4.2 | Os números são justificados à direita e alinhados quanto aos decimais? | [ ] [ ] [ ] |  |
| 4.3 | Os ícones e ilustrções são rotulados? | [ ] [ ] [ ] |  |
| 4.4 | As instruções aparecem de forma consistente sempre no mesmo local? | [ ] [ ] [ ] |  |
| 4.5 | Os objetos do sistema são nomeados de maneira conssitente em todo o sistema? | [ ] [ ] [ ] |  |
| 4.6 | Os campos obrigatórios e opcionais são corretamente sinalizados? | [ ] [ ] [ ] |  |
| 5 - Prevenção de erros |
| 5.1 | As opções de menu são lógicas, distintas e mutualmente exclusivas? | [ ] [ ] [ ] |  |
| 5.2 | Se o sistema exibe múltiplas janelas, a navegação entre janelas é simples e visível? | [ ] [ ] [ ] |  |
| 5.3 | O sistema alerta o usuário se ele está prestes a fazer erros críticos? | [ ] [ ] [ ] |  |
| 6 - Reconhecimento ao invés de recordação |
| 6.1 | Há distinção clara quando é possível selecionar um item ou vários? | [ ] [ ] [ ] |  |
| 6.2 | Os rótulos de campo estão próximos dos campos e separados pelo menos um espaço? | [ ] [ ] [ ] |  |
| 6.3 | São utulizadas bordas para identificar possiveis grupois de elementos? | [ ] [ ] [ ] |  |
| 6.4 | Existem opções default para o que o usuário precisa selecionar? | [ ] [ ] [ ] |  |
| 6.5 | Há alguma diferença visível para identificar a janela ativa? | [ ] [ ] [ ] |  |
| 7 - Flexibilidade e eficiência de uso |
| 7.1 | Existem atalhos para as funções disponíveis no sistema? | [ ] [ ] [ ] |  |
| 7.2 | O usuário pode realizar a tarefa de maneiras mais simplificadas? | [ ] [ ] [ ] |  |
| 7.3 | O sistema permite integração com outras fontes das informações tratadas? | [ ] [ ] [ ] |  |
| 8 - Estética e design minimalista |
| 8.1 | Apenas a informação necessária para ação está visível na tela? | [ ] [ ] [ ] |  |
| 8.2 | Os ícones e ilustrações estão distintos do seu fundo? | [ ] [ ] [ ] |  |
| 8.3 | Os agrupamentos são separados por espaço em branco? | [ ] [ ] [ ] |  |
| 8.4 | Os rótulos e menus são breves, familiares e descritivos das opções que representam? | [ ] [ ] [ ] |  |
| 9 - Ajudar os usuários e reconhecer, diagnosticar se recuperar de erros |
| 9.1 | É utilizado um sinal sonoro para alertar de erros? | [ ] [ ] [ ] |  |
| 9.2 | Os questionamentos são breves e sem ambiguidade? | [ ] [ ] [ ] |  |
| 9.3 | Se um erro é detectado, o usuário tem visibilidade sobre qual o local gerador do erro? | [ ] [ ] [ ] |  |
| 9.4 | As mensagens de erro identificam a severidade e a causa do erro? | [ ] [ ] [ ] |  |
| 9.5 | As mensagens de erro sugerem uma ação para correção? | [ ] [ ] [ ] |  |
| 10 - Ajuda e documentação |
| 10.1 | As instruções online es~toa visualemnte distintas? | [ ] [ ] [ ] |  |
| 10.2 | Existe ajuda online sensível ao contexto? | [ ] [ ] [ ] |  |
| 10.3 | É simples o acesso a ajuda do sistema e retorno ao sistema? | [ ] [ ] [ ] |  |





**Modelo de teste: Descoberta de problemas**

`Objetivos do teste` - Identificar e corrigir eventuais problemas existentes na plataforma além de mensurar a qualidade de navegação e satisfação do usuário. 

`Tarefa de teste` - Será atribuído um valor simbólico ao usuário no total de R$ 500,00 e solicitado que seja feito a distribuição do valor em um total de 6 lançamentos com pelo menos 1 categoria para cada lançamento. Após os lançamentos o usuário deve agrupar lançamentos de acordo com os tipos de categorias (Ex:  crédito + débito + passivo) e definir uma meta para fazer uma simulação de um futuro lançamento para obter possíveis cenários de atingimento da meta. **O teste terá um tempo pré-determinado de 5 minutos para ser realizado**

`Critérios de seleção dos participantes` - Será feito um questionário com perguntas relacionadas a vida financeira do participante. Serão escolhidos participantes ativos financeiramente que ganham até 1 salário-mínimo e meio com perfil próximo ao das personas do projeto. 

 `Procedimentos a serem adotados pelo condutor` - O condutor observará o teste de maneira remota e não moderado utilizando o método de avaliação coletando dados como quantidades de cliques e o tempo de cumprimento do teste.

