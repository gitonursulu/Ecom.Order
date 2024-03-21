from locust import HttpUser, between, task

class WebsiteUser(HttpUser):
    wait_time = between(1, 1)
    
    @task
    def order_get(self):
        self.client.get("/Test")
        

