# Commands
## Initialize terraform
```
terraform init
```
## Output execution plan
```
terraform plan -out main.tfplan
```
## Apply execution plan
```
terraform apply "main.tfplan"
```

## Apply and override the variable value using command line
terraform apply -var "region=us-east-1"

## Inspect current state
```
terraform show
```

## Print output values
```
terraform output
```

## Destroy all resources
```
terraform destroy
```
