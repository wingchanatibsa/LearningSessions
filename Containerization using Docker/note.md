Containerization
- share the same host kernel but isolated from each other thru private namespaces and resource control mechanism at the OS level.
- Containers implement isolation of processes at OS level, avoiding overhead.
- You don't have to pre-allocate the memory for creating containers.
- has better resource utilization compared to VMs and short boot-up process.
- Containers are super portable, it virtualize CPU, memory, storage and network resources at the OS level. It create a sandboxed environment for your applications. 

Docker
- most popular open-source container format available and supported by many cloud providers suck as Amazon AWS (EKS), Google GCP  and Microsoft Azure - (AKS).

VM vs Containers
- VM required to pre-allocate CPU, Memory, Storage and Network resources before creating a VM.
- Containers is allocated dynamically.
- VM runs on Guest OS which required more complicated installation and configuration before it can run. VM boot up time is longer and VM size are much larger than Containers.
