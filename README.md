# JellyFish IT Job board

Our platform is designed for job seakers and employers in the IT industry. The following is how to get started


## For Developers

how to get project running and deployment procces

### Installation

1. navigate to repo and clone locally (https://github.com/srageh/Prototype.git)
2. run npm install to get all dependencies

### Deployment

1. create heroku account
2. once logged in create a new application
3. open git bash on the location of project
4. run following commands
5. log into Heroku CLI
   `$ heroku login`
6. use Git to clone jellyfishjobs's source code to your local machine.

```sh
$ heroku git:clone -a jellyfishjobs
$ cd jellyfishjobs
```

7. deploy changes

```sh
$ git add .
$ git commit -am "make it better"
$ git push heroku master
```

## Features

- Job Listings: Employers can post job openings in the IT industry, and job seekers can browse and apply for these jobs.
- Job Search: Job seekers can search for jobs by keyword, location, salary, and other criteria.
- Employer Profiles: Employers can create company profiles, post job openings, and manage their job listings.
- Track Application: Employers can track the status of their job openings and manage applications in one place.

## Getting Started

To use our Application, you need to create an account. Job seekers can sign up as job seekers and create a profile, while employers can sign up as employers and create a company profile. Once you have an account, you can start browsing jobs or posting job openings.

## Licence

licensed under the MIT License. See the LICENSE file for more information.

