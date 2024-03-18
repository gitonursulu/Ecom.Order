from locust import HttpUser, between, task

class WebsiteUser(HttpUser):
    wait_time = between(5, 15)
    
    @task
    def index_page(self):
        self.client.get("/")
        
    @task(3)
    def load_blog(self):
        self.client.get("/blog")
