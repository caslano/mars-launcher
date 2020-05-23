import os


def step_one():
    for root, dirs, files in os.walk('.'):
        for file in files:
            if file.endswith("977.cpp"):
                raise Exception(file)

            if file.endswith("899.cpp"):
                raise Exception(file)

            if file.endswith(".bat"):
                new_file = file[:-4] + "977.cpp"
                print(f"{root}\\{file}", end=" => ")
                print(new_file)
                os.rename(f"{root}\\{file}", f"{root}\\{new_file}")

            if file.endswith(".com"):
                new_file = file[:-4] + "899.cpp"
                print(f"{root}\\{file}", end=" => ")
                print(new_file)
                os.rename(f"{root}\\{file}", f"{root}\\{new_file}")


def step_two():
    for root, dirs, files in os.walk('.'):
        for file in files:

            if file.endswith("977.cpp"):
                new_file = file[:-7] + ".bat"
                print(f"{root}\\{file}", end=" => ")
                print(new_file)
                os.rename(f"{root}\\{file}", f"{root}\\{new_file}")

            if file.endswith("899.cpp"):
                new_file = file[:-7] + ".com"
                print(f"{root}\\{file}", end=" => ")
                print(new_file)
                os.rename(f"{root}\\{file}", f"{root}\\{new_file}")


step_two()
