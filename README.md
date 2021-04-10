# Sistema de Gestão Municipal (SGM)
POC do TCC da Pós em Arquitetura de Sistemas Distribuídos / Puc Minas


## Iniciar Sistema

```
$ docker-compose up -d --build
```

# Acessar sistema

- http://localhost:80/	


# Links Úteis
- http://localhost:80/  (principal do sistema)
- http://localhost:8082/ (phpMyAdmin) user=root passworod=456852
- http://localhost:7000/auth/swagger (módulo de autenticação)
- http://localhost:7000/cidadao/swagger (módulo de cidadao)
- http://localhost:7000/gestao/swagger (módulo de gestão)

Obs: add autencicação "Bearer <token>"


Ajustes
 - bloquear esse cara quando não autenticado -> http://sgm.canadaeast.cloudapp.azure.com/modulos
 - Voltar em todas as paginas
 - Criar simulação de integração com todo os outros modulos
​ - Acentuação
 - Escrever mais na Conclusão
 - Trocar vagas por Oportunidades
 - Módulo de Gestão – Inserir treinamento trocar CREATE por Inserir

melhoria
 - um voto a cada cpf

 