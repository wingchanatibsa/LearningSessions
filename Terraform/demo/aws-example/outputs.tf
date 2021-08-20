output "vpc-id" {
  value = aws_vpc.terraform_example.id
}

output "default-security-group-id" {
  value = aws_vpc.terraform_example.default_security_group_id
}

output "default-subnet-id" {
  value = aws_subnet.main.id
}

output "app-server-id" {
  value = aws_instance.app_server.id
}
