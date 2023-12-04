1 Eclipseworks

2 Refinamento
•	“Um projeto é uma entidade que contém várias tarefas. Um usuário pode criar, visualizar e gerenciar vários projetos”. Definir exatamente o que cada usuário/perfil pode fazer.  
•	Cada usuário pode cadastrar quantos projetos quiser? Há limite? 
•	Quais são as validações necessárias para o cadastro de projeto?
•	“projeto não pode ser removido se ainda houver tarefas pendentes associadas a ele”. Vale o mesmo para em andamento?
•	Na remoção de projeto, não seria mais adequado inativar o projeto e manter o histórico ao invés de remover o projeto e tarefas?
•	As alterações nos projetos não devem ter histórico como as tarefas?
•	Os projetos não tem comentários?
•	O projeto está em um contexto de empresa, cliente, etc? Haverá necessidade de criação de novas entidades? 
•	Haverá diferenciação de projetos por tipo? Terão algum tipo de cálculo específico por projeto? Propriedades ou métodos diferenciados? Vale o mesmo para as tarefas.
•	Qual é o número aproximado de projetos e tarefas que o sistema terá cadastrado (desempenho futuro)?
•	Poderão ser vinculados recursos (usuários) à uma determinada tarefa na sua execução?
•	O histórico de atualizações pode ser feito com CDC no sqlServer. O registro desse histórico na aplicação deixa a funcionalidade de atualização mais lenta. 
•	A adição de comentários deve ser feita em uma tabela específica para registro de comentários (a modelagem do sistema é por conta dos devs). 
•	Permissões relativas aos Relatórios devem estar definidas nos perfis, portanto definir os papéis e funções antes.


3 Final
•	Um ponto de melhoria claro é a questão do registro de histórico e comentários relativos às tarefas. O modo que foi passado ao dev não faz sentido do ponto de vista da modelagem, e performance. Poderia ser habilitado o CDC (captura de dados de alterações) no SqlServer poupando tempo de desenvolvimento. Talvez desenvolver uma consulta às tabelas das alterações somente.
•	No caso da especificação do registro de histórico, o padrão observer parece ser uma opção para implementação desse registro pois isso seria uma resposta ao evento de atualização da tarefa. Porém o caso parece ser um problema mais de modelagem e utilização de outros recursos para solução do registro. 
•	Conforme a consulta ao P.O. em relação à regra de projetos e tarefas e suas especificações, poderiam ser utilizados Creational Patterns como o factory method para a criação de subclasses de projeto ou tarefa.   
•	No caso o aumento da complexidade do projeto e comunicação com elementos externos podem ser utilizados structural patterns como o adapter ou o facade.
•	 Conforme a necessidade de cálculos com regras distintas para cada projeto, cabe a utilização do strategy.

A utilização de padrões até o momento fica como especulação pois a regra de negócio é muito simples e não dá a idéia do sistema como um todo.

3 - O sistema enviado foi feito numa arquitetura de camadas, monolítico, com estrutura preservando as camadas do core. Essa estrutura remete à clean arquictecture. Foi desenvolvido com um banco de dados único, SqlServer. Esse sistema, aplicação e banco, pode ser hospedado em algum serviço de cloud rodando numa Ec2 com Windows na AWS por exemplo. Existem inúmeras configurações para hospedagem do sistema. Faz-se necessária uma avaliação da necessidade da empresa e os custos envolvidos na configuração dos ambientes de dev, homologação e produção. O sistema, conforme sua utilização e evolução, pode ter necessidade de alteração de tecnologia, arquitetura, tamanho ou número de máquinas disponíveis, escalonamento, segurança, armazenamento extra, etc. Tudo isso deve ser analisado no levantamento inicial de requisitos. À princípio foi desenvolvido um sistema de arquitetura de camadas simples, mas existe a possibilidade de alteração para microsserviços onde seriam mais adequados padrões como CQRS (direcionamento de escrita para banco relacional e leitura para não relacional), divisão de serviços em aplicações diferentes, configuração de escalonamento etc.  
