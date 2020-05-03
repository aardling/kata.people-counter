FROM tiangolo/uwsgi-nginx-flask:python3.7
ENV STATIC_URL /static
ENV STATIC_PATH /app/static
COPY ./requirements.txt /app/requirements.txt
RUN pip install -r /app/requirements.txt
COPY ./app /app
