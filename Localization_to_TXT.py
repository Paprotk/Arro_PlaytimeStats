import tkinter as tk
import tkinter.scrolledtext as scrolledtext
from tkinter import filedialog
import re

def find_localized_string_in_file(filename):
    try:
        with open(filename, 'r', encoding='utf-8') as file:
            content = file.read()
            regex = r'Localization\.LocalizeString\(false, "(.*?)", new object\[0\]\);'
            matches = re.findall(regex, content, re.DOTALL)
            return matches
    except FileNotFoundError:
        return [f'File {filename} not found.']
    except Exception as e:
        return [f'An error occurred: {e}']

def open_file_dialog():
    filenames = filedialog.askopenfilenames(filetypes=[("C# files", "*.cs")])
    if filenames:
        text_area.delete(1.0, tk.END)  
        text_area.insert(tk.END, '<?xml version="1.0" ?>\n<TEXT>\n\n')  
        for filename in filenames:
            matches = find_localized_string_in_file(filename)
            for match in matches:
                formatted_match = f'<KEY>{match}</KEY>\n<STR></STR>\n\n' 
                text_area.insert(tk.END, formatted_match)
        text_area.insert(tk.END, '</TEXT>')  
        text_area.update_idletasks()
        
        
        save_button.config(state=tk.NORMAL)

def save_to_file():
    content = text_area.get(1.0, tk.END)
    filename = filedialog.asksaveasfilename(defaultextension=".txt", filetypes=[("Text files", "*.txt")])
    if filename:
        with open(filename, 'w', encoding='utf-8') as file:
            file.write(content)


root = tk.Tk()
root.title("Open .cs Files")


root.geometry('600x400')


open_button = tk.Button(root, text="Open .cs files", command=open_file_dialog, padx=10, pady=5)
open_button.pack(pady=20)


save_button = tk.Button(root, text="Save as TXT", command=save_to_file, padx=10, pady=5, state=tk.DISABLED)
save_button.pack(pady=10)


text_area = scrolledtext.ScrolledText(root, wrap=tk.WORD, width=80, height=20)
text_area.pack(padx=20, pady=10)

root.mainloop()
