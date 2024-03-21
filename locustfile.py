from locust import HttpUser, between, task

class WebsiteUser(HttpUser):
    wait_time = between(1, 1)
    
    @task
    def order_get(self):
        self.client.get("/Test?id=533DF7A7-99C0-4FAA-89A3-08DC49B090BD")
        

