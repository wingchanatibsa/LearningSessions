# Configure the AWS Provider
provider "aws" {
  profile = "default"
  region  = var.region
}

# Create a VPC
resource "aws_vpc" "terraform_example" {
  cidr_block = "10.0.0.0/16"
}

# create subnet
resource "aws_subnet" "main" {
  vpc_id     = aws_vpc.terraform_example.id
  cidr_block = "10.0.1.0/24"

  tags = {
    Name = "Main"
  }
}

#create a EC2 instance
resource "aws_instance" "app_server" {
  ami                    = var.app_server_ami
  instance_type          = "t2.micro"
  vpc_security_group_ids = [aws_vpc.terraform_example.default_security_group_id]
  subnet_id              = aws_subnet.main.id
  tags = {
    Name        = "Terraform-Example"
    Environment = "Test"
  }
}