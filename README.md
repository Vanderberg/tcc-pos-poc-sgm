# Sistema de Gestão Municipal (SGM)
POC do TCC da Pós em Arquitetura de Sistemas Distribuídos / Puc Minas


## Iniciar Sistema

```
$ docker-compose up -d --build
```

# Acessar sistema

- http://localhost:81/	


# Links Úteis
- http://localhost:81/  (principal do sistema)
- http://localhost:8082/ (phpMyAdmin) user=root passworod=456852
- http://localhost:7000/auth/swagger (módulo de autenticação)
- http://localhost:7000/cidadao/swagger (módulo de cidadao)
- http://localhost:7000/gestao/swagger (módulo de gestão)

Obs: add autencicação "Bearer <token>"