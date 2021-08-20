variable "region" {
  description = "Value of the aws region"
  type        = string
  default     = "us-east-1"
}

#app_server AMI: Ubuntu Server 20.04 LTS (HVM), SSD Volume Type, 64-bit (x86)
variable "app_server_ami" {
  default = "ami-09e67e426f25ce0d7"
  type    = string
}

#app_server AMI: Amazon Linux 2 AMI (HVM), SSD Volume Type, 64-bit (x86)
# variable "app_server_ami" {
#   default = "ami-0c2b8ca1dad447f8a" 
#   type = string
# }
